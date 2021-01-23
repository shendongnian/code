    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace ConsoleApplication4
    {
        public class Employee
        {
            public Employee[] ChildOrg { get; set; }
            public string     name     { get; set; }
            public string     id       { get; set; }
        }
        public static class Program
        {
            public static IEnumerable<Employee> AllEmployees(Employee root)
            {
                if (root == null)
                    yield break;
                yield return root;
                if (root.ChildOrg == null)
                    yield break;
                foreach (var child in root.ChildOrg.SelectMany(AllEmployees))
                    yield return child;
            }
            private static void Main()
            {
                Employee root = new Employee  { name = "root", id = "root" };
                createChildren(root, 4, 4, 0);
                Console.WriteLine("All employees:");
                Console.WriteLine(string.Join("\n", AllEmployees(root).Select(node => node.id)));
                Console.WriteLine("\nAll nodes with an id that ends in 0:");
                var allNodesWithIdEndingIn0 = AllEmployees(root).Where(node => node.id.EndsWith("0"));
                Console.WriteLine(string.Join("\n", allNodesWithIdEndingIn0.Select(node => node.id)));
            }
            private static int createChildren(Employee root, int depth, int width, int count)
            {
                if (depth == 0)
                    return count;
                root.ChildOrg = new Employee[width];
                for (int i = 0; i < width; ++i)
                {
                    var node = new Employee { id = count.ToString() };
                    root.ChildOrg[i] = node;
                    count = createChildren(node, depth-1, width, count+1);
                }
                return count;
            }
        }
    }
