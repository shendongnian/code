    var mainThread = Task.Factory.StartNew(() =>
          {
                 var tasks = addresses.Select(x => Task.Factory.StartNew(() =>
                     {
                           // Do your download stuff for one address
                           return "someContent";
                     });
                
                Task.WaitAll(tasks); // Blocks all the minor tasks, waits until they all complete
                return tasks.Select(x => x.Result).ToList(); // You may observe exceptions here
          });
    var allResults = mainThread.Result; // List<string>, blocks until all tasks are complete
                                        // can also observe exceptions here
    return View(allResults);
