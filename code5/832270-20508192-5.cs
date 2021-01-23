    <ul>
        @foreach (System.Collections.DictionaryEntry ev in Environment.GetEnvironmentVariables())
        {
            if (ev.Value.ToString().ToLower().Contains("data source"))
            {
                <li><strong>@ev.Key.ToString()</strong> @ev.Value.ToString()</li>
            }
        }
    </ul>
    <ul>
        @foreach (System.Configuration.ConnectionStringSettings cs in System.Configuration.ConfigurationManager.ConnectionStrings)
        {
            <li><strong>@cs.Name</strong> @cs.ConnectionString</li>
        }
    </ul>
