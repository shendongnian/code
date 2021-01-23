    private void ListImages()
            {
                DirectoryInfo dir = new DirectoryInfo(MapPath("~/images/Animal")); // it's will be animal if i click on animal and flower when i click on flower.
                FileInfo[] file = dir.GetFiles();
                // ArrayList list = new ArrayList();
                List<ImageTest> list = new List<ImageTest>();
                foreach (FileInfo file2 in file)
                {
                    if (file2.Extension == ".jpg" || file2.Extension == ".jpeg" || file2.Extension == ".gif" || file2.Extension == ".png")
                    {
                        // list.Add(file2);
                        // list.Add(dir.ToString() + file2.ToString());
                        list.Add(new test()
                                     {
                                         Name = "http://localhost:58822/Images/Animal/" + file2.ToString() // where localhost path would be your site url
                                     });
                    }
                }
                DataList1.DataSource = list;
                DataList1.DataBind();
            }
