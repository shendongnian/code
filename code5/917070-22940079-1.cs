        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var parents = GetParents();
            foreach (var parent in parents)
            {
                Console.WriteLine(@"Parent: " + parent.ParentId);
                foreach (var child in parent.Children)
                {
                    Console.WriteLine(@"Child: " + child.ChildId);
                }
            }
        }
        private List<Parent> GetParents()
        {
            var context = new EFTestDBEntities();
            var parentList = context.Parents.Where(x => x.ParentId == 1).ToList();
            foreach (var parent in parentList)
            {
                // Commenting out the following line makes the above Console.WriteLines enumerate all children
                ((IObjectContextAdapter)context).ObjectContext.Detach(parent);
                parent.Children = context.Children.Where(x => x.ChildId == 1).ToList();
            }
            return parentList;
        }
