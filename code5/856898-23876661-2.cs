    using System;
    using System.Collections.Generic;
    using System.Linq;
    /// <summary>
    /// Interface to define objects which can be topologically sorted.
    /// </summary>
    /// <typeparam name="T">Type of underlying object.</typeparam>
    public interface ITopologicSortable<T>
    {
        /// <summary>
        /// Unique identifer of the item.
        /// </summary>
        Guid Identifier { get; }
        /// <summary>
        /// Gets or sets a list of object the current item depends on.
        /// </summary>
        ObservableCollection<T> DependsOn { get; set; }
    }
    
    /// <summary>
    /// Extension method to implement topologic sorting. Will return a list where items with dependencies
    /// will come after items without dependencies.
    /// </summary>
    /// <remarks>
    /// From http://stackoverflow.com/questions/21189222/topological-sort-with-support-for-cyclic-dependencies
    /// </remarks>
    public static class TopologicSortExtensions
    {
        /// <summary>
        /// Sorts a list of items with dependencies such that items without dependencies come first.
        /// </summary>
        /// <typeparam name="T">Type of list, which must implement <see cref="ITopologicSortable"/>.</typeparam>
        /// <param name="graph">List of items to sort.</param>
        /// <returns>A sorted list of item, where items with dependencies after items without dependencies.</returns>
        public static List<T> TopologicSort<T>(this List<T> graph)
            where T : ITopologicSortable<T>
        {
            int[] state = new int[graph.Count];
            List<T> list = new List<T>();
            for (int i = 0; i < graph.Count; i++)
            {
                state[i] = 1; /* alive */
            }
            for (int i = 0; i < graph.Count; i++)
            {
                visit(graph, i, list, state);
            }
            return list;
        }
        private static void visit<T>(List<T> graph, int index, List<T> list, int[] state)
            where T : ITopologicSortable<T>
        {
            if (state[index] == -1) /* dead */
            {
                return; // We've done this one already.
            }
            if (state[index] == 0) /* processing */
            {
                return; // We have a cycle; if you have special cycle handling code do it here.
            }
            // It's alive. Mark it as undead.
            state[index] = 0; /* processing */
            foreach (T neighbour in getNeighbours(graph, graph[index]))
            {
                visit(graph, graph.IndexOf(neighbour), list, state);
            }
            state[index] = -1; /* dead */
            list.Add(graph[index]);
        }
        private static List<T> getNeighbours<T>(List<T> graph, T node)
            where T : ITopologicSortable<T>
        {
            List<T> neighbours = new List<T>();
            graph.ForEach(x => x.DependsOn.Where(y => y.Identifier == node.Identifier).ToList().ForEach(z =>
            {
                neighbours.Add(z);
            }));
            node.DependsOn.ToList().ForEach(x => neighbours.Add(x));
            List<T> unique = new List<T>();
            neighbours.ForEach(x =>
            {
                if (!unique.Any(y => y.Identifier == x.Identifier))
                {
                    unique.Add(x);
                }
            });
            // can't be neighbors with yourself
            if (unique.IndexOf(node) > -1)
            {
                unique.Remove(node);
            }
            return unique;
        }
    }
    
    
    public class Foo : ITopologicSortable<Foo>
    {
        private bool _dependenciesAreResolved = false;
        private Guid _identifier;
        
        /// <summary>
        /// Child items that will be executed.
        /// </summary>
        public ObservableCollection<Foo> Children { get; set; }
        
        /// <summary>
        /// List of all pre-requisite Foos that must be executed first.
        /// </summary>
        public ObservableCollection<Foo> DependsOn { get; set; }
        
        /// <summary>
        /// Gets the unique identifier of the Foo.
        /// </summary>
        public Guid Identifier
        {
            get
            {
                return _identifier;
            }
        }
        
        /// <summary>
        /// Creates a new Foo
        /// </summary>
        public Foo()
        {
            _identifier = Guid.NewGuid();
            
            DependsOn = new ObservableCollection<Foo>();
            Children = new ObservableCollection<Foo>();
            
            // Flag that dependencies must be recalculated when collections change
            DependsOn.CollectionChanged += (s, e) =>
            {
                _dependenciesAreResolved = false;
            };
            Children.CollectionChanged += (s, e) =>
            {
                _dependenciesAreResolved = false;
            };
        }
        
        /// <summary>
        /// Sorts all Foos and child Foos so that the items can be displayed in the correct order in the user interface.
        /// </summary>
        public void SortSelfAndDescendents()
        {
            if (_dependenciesAreResolved == false)
            {
                ResolveDependencies();
            }
            if (Children.Count > 0)
            {
                Children.ToList().ForEach(x => x.SortSelfAndDescendents());
            }
        }
        
        /// <summary>
        /// Helper function to sort the children of the current item if they are not already sorted.
        /// </summary>
        private void ResolveDependencies()
        {
            _dependenciesAreResolved = true;
            if (Children.Count == 0)
            {
                return;
            }
            List<Foo> temp = new List<Foo>();
            Children.ToList().TopologicSort().ForEach(x => temp.Add(x));
            Children.Clear();
            temp.ForEach(x => Children.Add(x));
            // notify Children OnPropertyChanged here
        }
    }
