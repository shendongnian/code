    string content = string.Empty;
    string resource_file = "Data/myfile.json";
    if (IsLocalResourceFileExists(resource_file))
            {
                var resource = Application.GetResourceStream(new Uri(@"/YourProjectName;component/" + resource_file, UriKind.Relative));
                StreamReader streamReader = new StreamReader(resource.Stream, System.Text.Encoding.UTF8);
                content = streamReader.ReadToEnd();
                streamReader.Close();
            }
