    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    
    namespace ConsoleApplication3
    {
        class Program
        {
            static void Main(string[] args)
            {
                var master = FluentHelper.GridFor(new Model())
                .WithColumns(column =>
                    {
                        column.Bind(x => x.Name)
                            .WithCSS("inline");
                        column.Bind(x => x.Age)
                            .WithCSS("inline fixed right");
                    });
                    
                foreach(var c in master.children)
                {
                    Console.WriteLine(c.Binding.ToString());
                    Console.WriteLine(c.CSS);
                }
    
                Console.ReadKey(true);
            }
        }
    
        class Model
        {
            public string Name { get; set; }
            public string Age { get; set; }
        }
    
        class GridBuilder<T>
        {
            public GridBuilder<T> WithColumns(Action<ColumnBuilder<T>> bindAllColumns)
            {
                bindAllColumns(new ColumnBuilder<T>(this));
    
                return this;
            }
    
            public List<ColumnBuilder<T>> children = new List<ColumnBuilder<T>>();
        }
    
        class ColumnBuilder<T>
        {
            private GridBuilder<T> grid;
    
            public string Binding;
            public string CSS;
    
            public ColumnBuilder(GridBuilder<T> grid)
            {
                // TODO: Complete member initialization
                this.grid = grid;
            }
    
            public void WithCSS(string css)
            {
                this.CSS = css;
            }
    
            public ColumnBuilder<T> Bind<TItem>(Expression<Func<T, TItem>> propertySelector)
            {
                var builder = new ColumnBuilder<T>(grid);
    
                builder.Binding = (propertySelector.Body as MemberExpression).Member.Name;
    
                grid.children.Add(builder);
    
                return builder;
            }
        }
    
        static class FluentHelper
        {
    
            internal static GridBuilder<T> GridFor<T>(T model)
            {
                return new GridBuilder<T>();
            }
        }
    }
