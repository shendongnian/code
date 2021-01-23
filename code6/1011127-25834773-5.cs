	// don't use a cancellation token for the third task
	var task3 = Task.Factory.ContinueWhenAll(
						new[] { task1, task2 },
						tasks =>
						{
							if (tasks[0].Exception != null)
							{
								tasks[0].Exception.Handle(exc =>
								{
									Console.WriteLine("First task failed :(");
									return false; // signal that exception was handled, so it won't propagate
								});
								// add additional code here, or inside the Handle method above
							}
							if (tasks[1].Exception != null)
							{
								tasks[1].Exception.Handle(exc =>
								{
									Console.WriteLine("Second task failed :(");
									return false; // signal that exception was handled, so it won't propagate
								});
								// add additional code here, or inside the Handle method above
							}
							// do the same for the rest of the tasks or iterate throught them with a foreach loop...
						});
