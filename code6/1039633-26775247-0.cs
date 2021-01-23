    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        static class Program
        {
            /// <summary>
            /// Punto de entrada principal para la aplicación.
            /// </summary>
            [STAThread]
            static void Main()
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
    
                List<Parent> Parents = new List<Parent>();
                List<Parent> orderedParents = Parents.Cast<Parent>().OrderBy(x => x.Cast<Child>().Select(y => y.myName)).ToList();
            }
        }
    
        public class Parent: IQueryable 
        {
            List<Child> child = new List<Child>();
    
            #region Miembros de IQueryable
    
            public Type ElementType
            {
                get { throw new NotImplementedException(); }
            }
    
            public System.Linq.Expressions.Expression Expression
            {
                get { throw new NotImplementedException(); }
            }
    
            public IQueryProvider Provider
            {
                get { throw new NotImplementedException(); }
            }
    
            #endregion
    
            #region Miembros de IEnumerable
    
            public System.Collections.IEnumerator GetEnumerator()
            {
                throw new NotImplementedException();
            }
    
            #endregion
        }
    
        public class Child: Parent 
        {
            public string myName;
        }
    }
