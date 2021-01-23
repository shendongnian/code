    namespace SO.NBody
    {
        public class Particle
        {
            public double mass;
            public double[] position;
            public double[] velocity;
            public double[] acceleration;
            public Particle(double mass)
            {
                this.mass=mass;
                this.position=new double[Simulation.DOF];
                this.velocity=new double[Simulation.DOF];
                this.acceleration=new double[Simulation.DOF];
            }
        }
        public class Simulation
        {
            // Degrees of Freedom, Planar Simulation = 2, Spatial Simulation = 3
            public static int DOF=2;
            // Set Universal Gravity as Needed here
            public const double G=100;
            public Simulation()
            {
                Bodies=new List<Particle>();
                Time=0;
            }
            public List<Particle> Bodies { get; private set; }
            public double Time { get; set; }
            public void CalculateAllAccelerations()
            {
                for (int i=0; i<Bodies.Count; i++)
                {
                    Bodies[i].acceleration=new double[DOF];
                    for (int j=0; j<i; j++)
                    {
                        // Find relative position, which is needed for
                        //   a) Distance
                        //   b) Direction
                        double[] step=new double[DOF];
                        double distance=0;
                        for (int k=0; k<DOF; k++)
                        {
                            step[k]=Bodies[i].position[k]-Bodies[j].position[k];
                            // distance is |x^2+y^2+..|
                            distance+=step[k]*step[k];
                        }
                        distance=Math.Sqrt(distance);
                        // Law of gravity
                        double force=G*Bodies[i].mass*Bodies[j].mass/(distance*distance);
                        // direction vector from [j] to [i]
                        double[] direction=new double[DOF];
                        for (int k=0; k<DOF; k++)
                        {
                            direction[k]=step[k]/distance;
                        }
                        // Add equal and opposite acceleration components
                        for (int k=0; k<DOF; k++)
                        {
                            Bodies[i].acceleration[k]=-direction[k]*(force/Bodies[i].mass);
                            Bodies[j].acceleration[k]=+direction[k]*(force/Bodies[j].mass);
                        }
                    }
                }
            }
            public void UpdatePositions(double time_step)
            {
                CalculateAllAccelerations();
                // Use symplectic integration
                for (int i=0; i<Bodies.Count; i++)
                {
                    for (int k=0; k<DOF; k++)
                    {
                        Bodies[i].velocity[k]+=time_step*Bodies[i].acceleration[k];
                        Bodies[i].position[k]+=time_step*Bodies[i].velocity[k];
                    }
                }
                Time+=time_step;
            }
            public void RunSimulation(double end_time, int steps)
            {
                double h=(end_time-Time)/steps;
                while (Time<end_time)
                {
                    // Trim last step if needed so the sim ends when specified
                    if (Time+h>end_time) { h=end_time-Time; }
                    UpdatePositions(h);
                }
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                var world=new Simulation();
                var sun=new Particle(1000);
                var p1=new Particle(1.15)
                {
                    position=new double[] { 100, 0 },
                    velocity = new double[] { 0, 10 }
                };
                var p2=new Particle(1.05)
                {
                    position=new double[] { 120, 0 },
                    velocity=new double[] { 0, 6 }
                };
                // ...
                world.Bodies.Add(sun);
                world.Bodies.Add(p1);
                world.Bodies.Add(p2);
                //...
                world.RunSimulation(10.0, 100);
            }
        }
    }
