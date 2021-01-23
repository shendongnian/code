    string s = Model.Price.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
    string[] parts = s.Split('.');
    int i1 = int.Parse(parts[0]);
    int i2 = int.Parse(parts[1]);
    
    <span>@i1</span>
    <span class="decimal">@i2</span>
