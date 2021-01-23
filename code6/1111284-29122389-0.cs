                string result;
                using (System.IO.StreamReader reader = new System.IO.StreamReader("FILENAME", true))
                {
                    result = reader.ReadToEnd();
                }
