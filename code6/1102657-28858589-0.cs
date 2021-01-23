    using System.Reflection;
    ...
         var fi = typeof(StreamReader).GetField("_checkPreamble", BindingFlags.NonPublic | BindingFlags.Instance);
         fi.SetValue(sr, true);
         read = sr.ReadLine();
         Assert.AreEqual("fromfile", read); // okay now
