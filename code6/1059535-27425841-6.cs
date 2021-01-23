    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace ConsoleApplication4
    {
        public class Employee
        {
            public Employee[] ChildOrg
            {
                get;
                set;
            }
            public string name
            {
                get;
                set;
            }
            public string id
            {
                get;
                set;
            }
        }
        public class EmployeeAndParent
        {
            public EmployeeAndParent(Employee employee, Employee parent)
            {
                Employee = employee;
                Parent   = parent;
            }
            public readonly Employee Employee;
            public readonly Employee Parent;
        }
        public static class Program
        {
            public static IEnumerable<EmployeeAndParent> AllEmployees(Employee root, Employee parent)
            {
                if (root == null)
                    yield break;
                yield return new EmployeeAndParent(root, parent);
                if (root.ChildOrg == null)
                    yield break;
                foreach (var child in root.ChildOrg.SelectMany(child => AllEmployees(child, root)))
                    yield return child;
            }
            private static void Main()
            {
                Employee root = new Employee
                {
                    name = "root",
                    id = "root"
                };
                createChildren(root, 4, 4, 0);
                Console.WriteLine("All employees:");
                Console.WriteLine(string.Join("\n", AllEmployees(root, null).Select(node => node.Employee.id)));
                Console.WriteLine("\nAll nodes with an id that ends in 0:");
                var allNodesWithIdEndingIn0 = AllEmployees(root, null).Where(node => node.Employee.id.EndsWith("0"));
                Console.WriteLine(string.Join("\n", allNodesWithIdEndingIn0.Select(node => node.Employee.id)));
                Console.WriteLine("\nAll siblings of the node with id == 100, along with that node itself:");
                var foundNode = AllEmployees(root, null).Single(node => node.Employee.id == "100");
                Console.WriteLine(string.Join("\n", foundNode.Parent.ChildOrg.Select(node => node.id)));
            }
            private static int createChildren(Employee root, int depth, int width, int count)
            {
                if (depth == 0)
                    return count;
                root.ChildOrg = new Employee[width];
                for (int i = 0; i < width; ++i)
                {
                    var node = new Employee
                    {
                        id = count.ToString()
                    };
                    root.ChildOrg[i] = node;
                    count = createChildren(node, depth-1, width, count+1);
                }
                return count;
            }
        }
    }
