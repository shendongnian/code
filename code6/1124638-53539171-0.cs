				public List<List<RiverNode>> FindAllPathsBetweenTwoNodes(Node startNode, Node endNode, List<string> vistedNodes, List<Node> localpaths)
						{
							try
							{
								//Mark Current Node As Visited
								vistedNodes.Add(startNode.Name);
								if (localpaths.Count == 0)
								{
									localpaths.Add(startNode);
								}
								if (startNode.Name.Equals(endNode.Name))
								{
									BuildPath(localpaths);
								}
								foreach (var node in startNode.GetNeighbours())
								{
									if (!vistedNodes.Contains(node.Name))
									{
										localpaths.Add(node);
										FindAllPathsBetweenTwoNodes(node, endNode, vistedNodes, localpaths);
										localpaths.Remove(node);
									}
								}
								vistedNodes.Remove(startNode.Name);
								return allPaths;
							}
							catch (Exception ex)
							{
								throw;
							}
						}
						
						
						
						// <summary>
						/// Build Path
						/// </summary>
						/// <param name="localpath"></param>
						private void BuildPath(List<RiverNode> localpath)
						{
							var localbuilPath = new List<RiverNode>();
							foreach (var item in localpath)
							{
								localbuilPath.Add(item);
							}
							allPaths.Add(localbuilPath);
						}
