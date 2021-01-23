        using System.Collections.Generic;
        using System.Windows;
        using System.Windows.Documents;
        namespace WpfApplication2 {
            public class A {
                public int data { get; private set; }
                public A(int x) { data = x; }
            }
            public class B {
                public string data { get; private set; }
                public B(string x) { data = x; }
            }
            public class C {
                public A AData { get; set; }
                public B BData { get; set; }
            }
            public partial class MainWindow : Window {
                public MainWindow() {
                    InitializeComponent();
                    List<A> lIntegers = new List<A>() { new A(1), new A(2), new A(3), new A(4) };
                    List<B> lStrings = new List<B>() { new B("a"), new B("b"), new B("c"), new B("d") };
                    List<C> lParent = new List<C>();
                    for (int i = 0; i < 4; i++) {
                        C c = new C();
                        lParent.Add(c);
                        c.AData = lIntegers[i];
                        c.BData = lStrings[i];
                    }
                    DG1.DataContext = lParent;
                    DG2.DataContext = lParent;
                }
            }
        }
