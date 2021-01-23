    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person();
            person.Name = "Person One";
            person.Location = "India";
            person.Emails = new PersonEmails();
            person.Phones = new PersonPhones();
            person.Emails.Emails = new PersonEmail[] { new PersonEmail() { Type = "Official", Value = "xyz@official.com" }, new PersonEmail() { Type = "Personal", Value = "xyz@personal.com" } };
            person.Phones.Phones = new PersonPhone[] { new PersonPhone() { Type = "Official", Value = "789-456-1230" }, new PersonPhone() { Type = "Personal", Value = "123-456-7890" } };
            List<ObjectField> fields = new List<ObjectField>();
            fields = GetPropertyValues(person);
        }
        static List<ObjectField> GetPropertyValues(object obj)
        {
            List<ObjectField> propList = new List<ObjectField>();
            foreach (PropertyInfo pinfo in obj.GetType().GetProperties())
            {
                var value = pinfo.GetValue(obj, null);
                if (pinfo.PropertyType.IsArray)
                {
                    var arr = value as object[];
                    for (var i = 0; i < arr.Length; i++)
                    {
                        if (arr[i].GetType().IsPrimitive)
                        {
                            propList.Add(new ObjectField() { Name = pinfo.Name + i.ToString(), Value = arr[i].ToString() });
                        }
                        else
                        {
                            var lst = GetPropertyValues(arr[i]);
                            if (lst != null && lst.Count > 0)
                                propList.AddRange(lst);
                        }
                    }
                }
                else
                {
                    if (pinfo.PropertyType.IsPrimitive || value.GetType() == typeof(string))
                    {
                        propList.Add(new ObjectField() { Name = pinfo.Name, Value = value.ToString() });
                    }
                    else
                    {
                        var lst = GetPropertyValues(value);
                        if (lst != null && lst.Count > 0)
                            propList.AddRange(lst);
                    }
                }
            }
            return propList;
        }
    }
