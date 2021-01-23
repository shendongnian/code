     class Program
        {
            static void Main(string[] args)
            {
                Program p = new Program();
                Waveform waveform = new Waveform();
                p.DeleteEntity<Waveform>(waveform);
            }
    
            public void DeleteEntity<T>(T entity) where T : Waveform
            {
                List<Entity> parents = FindParents<T>(entity);
            }
    
            public virtual List<Entity> FindParents<T>(T possibleChild) where T : Waveform
            {
                List<Entity> dependsOnTypes = possibleChild.DependsOn();
                return dependsOnTypes;
            }        
        }
    
        public class Entity
        {
            protected Entity() { }
    
            public virtual List<Entity> DependsOn()
            {
                return new List<Entity>();
            }
        }
    
        public class Waveform : Entity
        {
            public virtual new List<Entity> DependsOn()
            {
                return new List<Entity> { new Scenario() };           
            }
        }
    
        public class Scenario: Entity
        {
            int x;
            float y;
        }
