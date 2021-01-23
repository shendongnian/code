    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading.Tasks;
    namespace WebApiConsoleApplication1
    {
        public static class UrlHelpers
        {
            /// <summary>
            /// To the query string. http://ole.michelsen.dk/blog/serialize-object-into-a-query-string-with-reflection.html 
            /// </summary>
            /// <param name="request"> The request. </param>
            /// <param name="separator"> The separator. </param>
            /// <returns></returns>
            /// <exception cref="System.ArgumentNullException"> request </exception>
            public static string ToQueryString(this object request, string innerPropertyName = null, string separator = ",")
            {
                if (request == null)
                {
                    throw new ArgumentNullException("request");
                }
    
                StringBuilder propertyQuery = new StringBuilder();
    
                // Get all primitive properties on the object 
                var properties = request.GetType().GetProperties()
                    .Where(x => x.CanRead)
                    .Where(x => x.GetValue(request, null) != null)
                    .Where(x => !x.PropertyType.IsClass || (x.PropertyType.IsClass && x.PropertyType.FullName == "System.String"))
                    .ToDictionary(x => x.Name, x => x.GetValue(request, null));
    
                foreach (KeyValuePair<string, object> kvp in properties)
                {
                    if (string.IsNullOrEmpty(innerPropertyName))
                    {
                        propertyQuery.AppendFormat("{0}={1}", Uri.EscapeDataString(kvp.Key), Uri.EscapeDataString(kvp.Value.ToString()));
                    }
                    else
                    {
                        propertyQuery.AppendFormat("{0}.{1}={2}", Uri.EscapeDataString(innerPropertyName), Uri.EscapeDataString(kvp.Key), Uri.EscapeDataString(kvp.Value.ToString()));
                    }
                    propertyQuery.AppendFormat("&");
                }
    
                var innerClass = request.GetType().GetProperties()
                    .Where(x => x.CanRead)
                    .Where(x => x.GetValue(request, null) != null && x.PropertyType.IsClass && x.PropertyType.FullName != "System.String" && !(x.GetValue(request, null) is IEnumerable))
                    .ToDictionary(x => x.Name, x => x.GetValue(request, null));
    
                // Get names for all IEnumerable properties (excl. string) 
                var propertyCollectionNames = request.GetType().GetProperties()
                    .Where(x => x.CanRead)
                    .Where(x => x.GetValue(request, null) != null)
                    .ToDictionary(x => x.Name, x => x.GetValue(request, null))
                    .Where(x => !(x.Value is string) && x.Value is IEnumerable)
                    .ToDictionary(x => x.Key, x => x.Value);
    
                // Concat all IEnumerable properties into a comma separated string 
                foreach (var kvp in propertyCollectionNames)
                {
                    var valueType = kvp.Value.GetType();
                    var valueElemType = valueType.IsGenericType
                                            ? valueType.GetGenericArguments()[0]
                                            : valueType.GetElementType();
                    if (valueElemType.IsPrimitive || valueElemType == typeof(string)) // List of primitive value type or string
                    {
                        var enumerable = kvp.Value as IEnumerable;
                        int count = 0;
                        foreach (object obj in enumerable)
                        {
                            if (string.IsNullOrEmpty(innerPropertyName))
                            {
                                propertyQuery.AppendFormat("{0}[{1}]={2}", Uri.EscapeDataString(kvp.Key), count, Uri.EscapeDataString(obj.ToString()));
                            }
                            else
                            {
                                propertyQuery.AppendFormat("{0}.{1}[{2}]={3}", Uri.EscapeDataString(innerPropertyName), Uri.EscapeDataString(kvp.Key), count, Uri.EscapeDataString(obj.ToString()));
                            }
                            count++;
                            propertyQuery.AppendFormat("&");
                        }
                    }
                    else if (valueElemType.IsClass) // list of class Objects
                    {
                        int count = 0;
                        foreach (var className in kvp.Value as IEnumerable)
                        {
                            string queryKey = string.Format("{0}[{1}]", kvp.Key, count);
                            propertyQuery.AppendFormat(ToQueryString(className, queryKey));
                            count++;
                        }
                    }
                }
    
                foreach (var className in innerClass)
                {
                    propertyQuery.AppendFormat(ToQueryString(className.Value, className.Key));
                }
    
                return propertyQuery.ToString();
            }
        }
    
        public class Employee
        {
            public string EmployeeId { get; set; }
    
            public string EmployeeName { get; set; }
    
            public int EmployeeRollNum { get; set; }
    
            public EmployeeAddress EmployeeAddr { get; set; }
    
            public List<EmployeeAddress> AllEmployeeAddr { get; set; }
        }
    
        public class EmployeeAddress
        {
            //[Required]
            public string EmployeeAddressId { get; set; }
    
            public string EmployeeAddressName { get; set; }
    
            public List<int> AllNum { get; set; }
        }
    
        internal class Program
        {
            private static void Main()
            {
                RunAsync().Wait();
                Console.WriteLine("Completed");
                Console.ReadLine();
            }
    
            private static async Task RunAsync()
            {
                try
                {
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(ConfigurationManager.AppSettings.Get("HostURL"));
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(ConfigurationManager.AppSettings.Get("AcceptType")));
    
                        HttpResponseMessage response = await client.GetAsync("api/Values/1");
                        if (response.IsSuccessStatusCode)
                        {
                            string val = await response.Content.ReadAsAsync<string>();
                            Console.WriteLine("{0}\t", val);
                        }
    
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(ConfigurationManager.AppSettings.Get("AcceptType")));
    
                        //client.DefaultRequestHeaders.Add()
                        // HTTP GET
                        Employee emp = new Employee();
                        emp.EmployeeId = "sri1";
    
                        emp.AllEmployeeAddr = new List<EmployeeAddress>();
                        EmployeeAddress lstemployeeAddr = new EmployeeAddress();
                        lstemployeeAddr.EmployeeAddressId = "Address1";
    
                        lstemployeeAddr.AllNum = new List<int>();
                        lstemployeeAddr.AllNum.Add(1);
                        lstemployeeAddr.AllNum.Add(2);
                        lstemployeeAddr.AllNum.Add(3);
                        emp.AllEmployeeAddr.Add(lstemployeeAddr);
    
                        lstemployeeAddr = new EmployeeAddress();
                        lstemployeeAddr.EmployeeAddressId = "Address2";
                        lstemployeeAddr.AllNum = new List<int>();
                        lstemployeeAddr.AllNum.Add(24);
                        lstemployeeAddr.AllNum.Add(56);
                        emp.AllEmployeeAddr.Add(lstemployeeAddr);
    
                        EmployeeAddress innerEmployeeAddr = new EmployeeAddress();
                        innerEmployeeAddr.EmployeeAddressId = "Addr3";
                        innerEmployeeAddr.AllNum = new List<int>();
                        innerEmployeeAddr.AllNum.Add(5);
                        innerEmployeeAddr.AllNum.Add(6);
                        emp.EmployeeAddr = innerEmployeeAddr;
    
                        string query = emp.ToQueryString();
    
                        response = await client.GetAsync("api/Values?" + query);
                        if (response.IsSuccessStatusCode)
                        {
                            Employee product = await response.Content.ReadAsAsync<Employee>();
                            Console.WriteLine("{0}\t{1}\t", product.EmployeeId, product.EmployeeName);
                        }
                    }
                }
                catch (Exception ex)
                {
                }
            }
        }
    }
