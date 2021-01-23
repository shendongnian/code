     public class Scene
     {
          public Scene(string name)
          {
              Name = name;
          }
          public string Name { get; set; }
          // ... more properties
 
          public void Draw()
          {
              // logic for drawing
          }
          
          // ... more methods.
          public override string ToString()
          {
              // here return what you would want to have as
              // a string representation of a Scene object.
              return "Scene " + Name;
          }
     }
     // in a different part of your code, create and add the Scene objects
     var scenesList = new List<Scene>();
     scenesList.Add(new Scene("Some scene name"));
     // add more
     
     // Now you can print them to the console like this:
     foreach (var scene in scenesList)
         Console.WriteLine(scene);
    
