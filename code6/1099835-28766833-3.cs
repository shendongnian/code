                HashSet<string> res = null;
				HashSet<string> outdictinary = null;
                foreach(string w in words)
                {
                    if (dt.TryGetValue(w, out outdictinary))
                    {
						if( res==null)
							res =new HashSet( outdictinary,outdictinary.Comparer);
						else
						{	
                            if (res.Count==0)
                                 break;
							res.IntersectWith(outdictinary);
						}
                    }
                }
                if (res==null) res = new HashSet();
                Console.WriteLine("Output After Intersection:");
                Console.WriteLine("Found {0} documents: ", res.Count);
                foreach(string s in res)
                {
                    Console.WriteLine(s);
                }
            
