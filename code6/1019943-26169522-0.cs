                Func<DirectoryInfo, IObservable<DirectoryInfo>> recurse = null;
                recurse = di =>
                    Observable
                        .Return(di)
                        .Concat(di.GetDirectories()
                            .Where(d => int.Parse(d.Name) <= br_tile[0] && int.Parse(d.Name) >= tl_tile[0])
                            .ToObservable()
                            .SelectMany(di2 => recurse(di2)))
                        .ObserveOn(Scheduler.Default);
                var query =
                    from di in recurse(new DirectoryInfo(Path.Combine(directory.FullName, baselvl.ToString())))
                    from fi in di.GetFiles().Where(f => int.Parse(Path.GetFileNameWithoutExtension(f.Name)) >= br_tile[1]
                        && int.Parse(Path.GetFileNameWithoutExtension(f.Name)) <= tl_tile[1]).ToObservable()
                    select fi;
                query.Subscribe(block.AsObserver());
                Console.WriteLine("Done subscribing");
                block.Complete();
                block.Completion.Wait();
                Console.WriteLine("Done TPL Block");
