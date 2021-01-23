        class Channel
        {
            private List<Rack> racks;
            
            public Channel()
            {
                racks = new List<Rack>();
            }
    
            public Channel(params Rack[] racks)
            {
                this.racks = racks.ToList();
            }
    
            public void send()
            {
                foreach (Rack item in racks)
                {
                    item.getData();
                }
    
            }
    
            public void SendSpecificRack(Rack rack)
            {
                //calls the getdata of the rack object passed
                rack.getData();
            }
    
        }
    
        public class Rack
        {
            public virtual void getData()
            {
                Console.WriteLine("Base Rack");
            }
        }
    
        public class RackChild1 : Rack
        {
            public override void getData()
            {
                Console.WriteLine("RackChild1");
            }
        }
    
        public class RackChild2 : Rack
        {
            public override void getData()
            {
                Console.WriteLine("RackChild2");
            }
        }
