					List list = new List(List.ORDERED, 20f);
					list.IndentationLeft = 20f;
					// add sublist
					List subList = new List(List.ORDERED);
					subList.PreSymbol = string.Format("{0}.", i);
					subList.Add("Something here");
					subList.Add("Something else here");
					list.Add(subList);
					doc.Add(list);
