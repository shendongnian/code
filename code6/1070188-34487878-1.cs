     private string SaveDataToSd(String FirstName, String Address, String Password)
        {
            var path = global::Android.OS.Environment.ExternalStorageDirectory.AbsolutePath;
            var filename = Path.Combine(path.ToString(), "loginSystem.txt");
            String contents = FirstName + "," + Password + "," + Address;
            try
            {
                using (StreamWriter data_file = new StreamWriter(filename, true))
                {
                    data_file.WriteLine(contents);
                }
                return contents;
            }
            catch (Exception ex)
            {
                RunOnUiThread(() =>
                {
                    var builder = new AlertDialog.Builder(this);
                    builder.SetMessage(ex.InnerException + "Saving file went wrong");
                    builder.SetTitle("Unable to save file");
                    builder.Show();
                });
                return String.Empty;
            }
        }
