    public static class DataSource
    {
        public const string Folder1 = "/folder1.png";
        public const string Folder2 = "/folder2.png";
        public const string Folder3 = "/folder3.png";
        public const string Folder4 = "/folder4.png";
        public static List<Folder> GetFolders()
        {
            return new List<Folder>
                {
                    new Folder("Conversation History"),
                    new Folder("Deleted Items",102)
                        {
                            ImageSource = Folder2,
                            Children =
                                {
                                    new Folder("Deleted Items #1"),
                                }
                        },
                    new Folder("Drafts",7)
                        {
                            ImageSource = Folder3,
                            ItemCountColor = "Green",
                        },
                    new Folder("Inbox",7)
                        {
                            ImageSource = Folder4,
                            Children =
                                {
                                    new Folder("_file")
                                        {
                                            Children =
                                                {
                                                    new Folder("__plans"),
                                                    new Folder("_CEN&ISO", 5),
                                                    new Folder("_DDMS", 1)
                                                    {
                                                        Children =
                                                            {
                                                                new Folder("Care Data Dictionary"),
                                                                new Folder("HPEN"),
                                                                new Folder("PR: Data Architecture"),
                                                                new Folder("PR: Hospital DS", 2),
                                                                new Folder("RDF"),
                                                                new Folder("Schemas"),
                                                                new Folder("Subsets"),
                                                            }
                                                    },
                                                    new Folder("_Interop")
                                                    {
                                                        Children =
                                                            {
                                                                new Folder("CDSA", 1),
                                                                new Folder("CPIS", 2),
                                                                new Folder("DMIC"),
                                                                new Folder("EOL"),
                                                                new Folder("... And so on..."),
                                                            }
                                                    }
                                                }
                                        }
                                }
                        }
                };
        }
    }
