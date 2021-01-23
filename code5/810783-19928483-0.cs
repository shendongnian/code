      try 
        {
          System.IO.File.Copy(strFile, strFile + ".new");
         //MyLibrary throws exception clases I defined so I know what they are all about
          MyLibrary.SomeClass.DoSomething(strFile);
        }
        catch(ExceptionTypeIDefinedInMyLibraryWhichIKnowICanSafelyIgnore iex)
        {
          Console.WriteLine("Not to worry: "+ iex.Message);
        }
        catch (Exception ex) 
        {
          //This absolute is not something I can handle. Log it and throw.
          Log(ex); throw;
        }
