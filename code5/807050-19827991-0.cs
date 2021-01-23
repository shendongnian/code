     public class Category
        {
            public string Name { get; set; }
            public Category Parent { get; set; }
            public ObservableCollection<Category> Items{get;set;}
            //Constructor
            public Category(string Cat_name, Category Cat_parent)
            {
                Name = Cat_name;
                Parent = Cat_parent;
                Items = new ObservableCollection<Category>();
            }
            /// <summary>
            /// Adds a child to this node
            /// </summary>
            /// <param name="child"></param>
            /// <returns></returns>
            public void AddChild(Category child)
            {
                if (child == null) //check if the child is not null
                    return;
                Items.Add(child);
            }
            /// <summary>
            /// Returns Root Parent
            /// </summary>
            /// <returns></returns>
            public Category RootPanel()
            {
                if (Parent == null)
                {
                    return this;
                }
                else
                {
                    return this.Parent.RootPanel();
                }
            }
        }
