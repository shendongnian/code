    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    class Program
    {
        static void Main(string[] args)
        {
            string json = @"
            {
              ""."": {
                ""proc"": {
                  ""15"": {
                    ""task"": {
                      ""15"": {
                        ""exe"": {},
                        ""mounts"": {
                          ""list_of_files"": [
                            ""mounts.xml""
                          ]
                        },
                        ""mountinfo"": {
                          ""list_of_files"": [
                            ""mountinfo.xml""
                          ]
                        },
                        ""clear_refs"": {
                          ""list_of_files"": [
                            ""clear_ref.xml""
                          ]
                        }
                      }
                    }
                  },
                  ""14"": {
                    ""loginuid"": {
                      ""list_of_files"": [
                        ""loginuid.xml""
                      ]
                    },
                    ""sessionid"": {
                      ""list_of_files"": [
                        ""sessionid.xml""
                      ]
                    },
                    ""coredump_filter"": {
                      ""list_of_files"": [
                        ""coredump_filter.xml""
                      ]
                    },
                    ""io"": {
                      ""list_of_files"": [
                        ""io.xml""
                      ]
                    }
                  }
                }
              }
            }";
            JObject jo = JObject.Parse(json);
            foreach (string path in CreateFileList(jo))
            {
                Console.WriteLine(path);
            }
        }
        private static List<string> CreateFileList(JObject jo)
        {
            List<string> ret = new List<string>();
            AddToFileList(jo, ret, "");
            return ret;
        }
        private static void AddToFileList(JObject jo, List<string> list, string prefix)
        {
            foreach (var kvp in jo)
            {
                if (kvp.Key == "list_of_files")
                {
                    foreach (string name in (JArray)kvp.Value)
                    {
                        list.Add(prefix + name);
                    }
                }
                else
                {
                    JObject dir = (JObject)kvp.Value;
                    if (dir.Count == 0)
                    {
                        list.Add(prefix + kvp.Key);
                    }
                    else
                    {
                        AddToFileList(dir, list, prefix + kvp.Key + "/");
                    }
                }
            }
        }
    }
