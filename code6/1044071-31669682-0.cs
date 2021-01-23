                // execute the request
                IRestResponse response = client.Execute(request);
                var content = response.Content; // raw content as string
                request = null;
                response = null;
                foreach (string file in files)
                {
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    var fileInfo = new FileInfo(file);
                    fileInfo.Refresh();
                    fileInfo.Delete();
                    File.Delete(file);
                }
                return content;
