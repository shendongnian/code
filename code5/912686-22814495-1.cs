    List<int> qty = new List<int>();
    foreach (string item in HttpContext.Current.Request.Form.GetValues("quantity_input"))
    {
        qty.Add(int.Parse(item));
    }
