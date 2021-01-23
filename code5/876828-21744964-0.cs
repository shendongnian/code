    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows;
    
    namespace WpfApplication7
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                Class1.foo();
            }
        }
    
        public class Class1
        {
            public static void foo()
            {
                new List<Class2>().IsReadableBy<Class2>();
                new List<Class1>().IsReadableBy<Class1>();
            }
        }
        public class Class2
        {
    
        }
    
        public static class myExtension // TODO: Rename.
        {
            public static IQueryable<Class1> IsReadableBy<T>(this IEnumerable<Class1> query)
                where T : Class1
            {
                Console.WriteLine("1");
                return null;
            }
    
            public static IQueryable<Class2> IsReadableBy<T>(this IEnumerable<Class2> query)
            where T : Class2
            {
                Console.WriteLine("2");
                return null;
            }
        }
    }
