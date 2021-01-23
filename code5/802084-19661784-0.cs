    Dictionary<string, string> masks = new Dictionary<string, string>();
    masks.Add("Phone", "{0:000-000-0000}");
    masks.Add("Time", "{0:00:00}");
    string test = "1234560789";
    string result = string.Format(masks["Phone"], int.Parse(test));
