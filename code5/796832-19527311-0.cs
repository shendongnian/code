                return (Directory.EnumerateFiles(
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
                    Globals.CompanyName, ProjectName, FolderName),
                imageExtension,
                SearchOption.TopDirectoryOnly)
                .Where(file => {
                    try
                    {
                        string relativePath = ClassFru.Station + "/"; // Inside ZIPs, paths use a single forward slash
                        var zip = new ZipFile();
                        zip.ZipError += (s, o) => {
                            throw new Exception();
                        };
                        using (zip = ZipFile.Read(file))
                        {
                            /// <todo>if (zip.Comment != Globals.CompanyName) { return false; }</todo>
                            foreach (var fru in this.gFrus)
                            {
                                var fruPath = relativePath + fru.Id + '.';
                                if(zip.Any(e=> !e.IsDirectory && e.FileName.StartsWith(fruPath))
                                        .Any())
                                {
                                    return false;
                                }
                            }
                            return true;
                        }
                    } catch (Exception)
                    {
                        return false;
                    }
                }).Select(Path.GetFileNameWithoutExtension).ToArray());
