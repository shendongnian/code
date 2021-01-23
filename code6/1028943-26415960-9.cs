                    foreach (int resourceId in allResourcesInOrder)
                    {
                        stream.Write(resourceId + ",");
                        stream.Write("Location ID" + ",");
                        stream.Write("Edition ID" + ",");
                        stream.Write("Click Count" + ",");
                        stream.Write("View Count" + ",");
                    }
                    stream.Write("\n");
