     Foo foo = new Foo(); // custom class
     string file = "export.CSV";
     if (System.IO.File.Exists(file))
     {             
          // Do work
          using (var reader = new StreamReader(file))
          {
              while (!reader.EndOfStream)
              {
                  // split on the delimeter
                  var readLine = reader.ReadLine();
                  if (readLine == null) continue;
                  var lines = readLine.Split(new[] { ',' });
                            
                  foreach (string s in lines)
                  {
                      // do something with the data from the line
                                           
                  }  
                  // alternatively, you could specify your objects if your files
                  // layout never changes. Just be careful to catch the exceptions! 
                  foo.bar = lines[0];
                  foo.baz = lines[1];
                  
              }
          }
     }
