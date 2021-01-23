      HashSet<Vector3> visitedTrees = new HashSet<Vector3>();
      var stripes = new Dictionary<int, List<Transform>>();
      int stripeNumber = 0;
      cameraPlane.SetNormalAndPosition(normal, view.camera.transform.position + normal * minDistance);
      int visited = 0;
      while (true)
      {
          bool reachedFarTree = false;
          foreach (var gameObject in trees)
          {
              float distance = cameraPlane.GetDistanceToPoint(gameObject.transform.position);
              Debug.Log("distances " + Mathf.Abs(distance));
              if (Mathf.Abs(distance) < 20 + offset)
              {
                  List<Transform> treeStripes;
                  if (!stripes.TryGetValue(stripeNumber, out treeStripes))
                  {
                      treeStripes = new List<Transform>();
                      stripes[stripeNumber] = treeStripes;
                  }
                  treeStripes.Add(gameObject.transform);
                  if (!visitedTrees.Contains(gameObject.transform.position))
                  {
                      visitedTrees.Add(gameObject.transform.position);
                      visited++;
                  }
               }
                    
          }
          if (trees.Count >= visited)
          {
              reachedFarTree = true;
          }
          offset += 20; // may try for a smaller value
          cameraPlane.SetNormalAndPosition(normal, view.camera.transform.position + normal * offset);
                stripeNumber++;
           if (reachedFarTree)
              break;
       }
