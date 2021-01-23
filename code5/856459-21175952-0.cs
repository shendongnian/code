    if (!File.Exists(fileNameToCheck))
                {
                    lblMessage.Text = "Missing file: " + names;
                    return false;
                }
                else
                {
                    return true;
                }
