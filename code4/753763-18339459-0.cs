    using System;
    class Program
    {
        static void Main()
        {
            Change();
            Replace();
            Inner();
        }
        static void Change()
        {
            try {
                try {
                    throw new Exception("This is a message");
                } catch (Exception e) {
                    e.Data.Add("foo", "bar");
                    throw;
                }
            } catch (Exception e) {
                System.Diagnostics.Trace.WriteLine(e.Message);
                System.Diagnostics.Trace.WriteLine(e.Data["foo"]);
            }
        }
        static void Replace()
        {
            try {
                try {
                    throw new Exception("This is a message");
                } catch (Exception e) {
                    e = new Exception("Different message", e);
                    e.Data.Add("foo", "bar");
                    throw;
                }
            } catch (Exception e) {
                System.Diagnostics.Trace.WriteLine(e.Message);
                System.Diagnostics.Trace.WriteLine(e.Data["foo"]);
            }
        }
        static void Inner()
        {
            try {
                try {
                    throw new Exception("This is a message");
                } catch (Exception e) {
                    e.Data.Add("foo1", "bar1");
                    e = new Exception("Different message", e);
                    e.Data.Add("foo2", "bar2");
                    throw e;
                }
            } catch (Exception e) {
                System.Diagnostics.Trace.WriteLine(e.Message);
                System.Diagnostics.Trace.WriteLine(e.Data["foo2"]);
                System.Diagnostics.Trace.WriteLine(e.InnerException.Message);
                System.Diagnostics.Trace.WriteLine(e.InnerException.Data["foo1"]);
            }
        }
    }
