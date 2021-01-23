    static void generator_GestureRecognized(object sender, GestureRecognizedEventArgs e)
            {
                Console.WriteLine("Gesture:{0}; Identified:{1}; End:{2}", e.Gesture, e.IdentifiedPosition.ToTripletString(), e.EndPosition.ToTripletString());
            }
    
   
    static void generator_GestureRecognized(object sender, GestureRecognizedEventArgs e)
            {
                handsGen.StartTracking(e.EndPosition);
                Console.WriteLine("Gesture:{0}; Identified:{1}; End:{2}", e.Gesture,     e.IdentifiedPosition.ToTripletString(), e.EndPosition.ToTripletString());
            }
