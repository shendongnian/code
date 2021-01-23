    <ul>
        @foreach (System.Collections.DictionaryEntry ev in Environment.GetEnvironmentVariables())
        {
            @if (ev.Value.ToString().ToLower().Contains("data source"))
            {
                <li>@ev.Key.ToString(), @ev.Value.ToString()</li>
            }
        }
    </ul>
    <ul>
        @foreach (System.Configuration.ConnectionStringSettings cs in System.Configuration.ConfigurationManager.ConnectionStrings)
        {
            <li>@cs.Name</li>
            <li>@cs.ConnectionString</li>
        }
    </ul>
