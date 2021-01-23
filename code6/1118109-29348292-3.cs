    ...
    string template = "Header2,Header3,Header1,Header4";
    //Defining the csvString. the 1st line is the header. each line is separated by '///'. each column is separated by ','  
    string csvString = "row11,row12,row13,row14///row21,row22,row23,row24///row31,row32,row33,row34";
    List<string> split = template.Split(',').ToList();
    // --------------------------------------------- SORT THE HEADERS!!!
    split.Sort(new ByNumberAtStringEnd());
    // Read into an array of strings.
    string[] source = csvString.Split(new string[] { "///" }, StringSplitOptions.None);
    var elements = from str in source
                   let fields = str.Split(',').ToList()
                   select new XElement("Client", split.Zip(fields, (name, value2) => new XElement(name, value2)));
    
    XElement cust = new XElement("Clients");
    cust.Add(elements);
