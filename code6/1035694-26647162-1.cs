    namespace ADQuery
    {
    class Program
    {
        static void Main(string[] args)
        {
            //GetUserLocalGroups("L_P00142", "10.18.6.9", "s-gruppe");
            DirectoryEntry root = new DirectoryEntry(String.Format("WinNT://{0},Computer", "ip-address"), null, null, AuthenticationTypes.Secure);
            DirectoryEntry admGroup = root.Children.Find("L_P00142W", "group");
            DoForEveryNode(admGroup);
        }
        static void DoForEveryNode(DirectoryEntry de)
        {
            if (de.SchemaClassName == "Group")
            {
                object members = de.Invoke("members", null);
                foreach (object groupMember in (IEnumerable)members)
                {
                    DirectoryEntry member = new DirectoryEntry(groupMember);
                    if (member.SchemaClassName == "User")
                        Console.WriteLine("I am a user: " + member.Name);
                    else
                    {
                        Console.WriteLine("I am a group: " + member.Name);
                        DoForEveryNode(member);
                    }
                }
                Console.ReadLine();
            }
        }
    }
    }
