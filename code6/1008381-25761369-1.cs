        using System.Threading.Tasks;
         
        ...
        Task t;
        public void Render(Object3D o) // renders 3D object
        {
            if(t.Status == System.Threading.Tasks.TaskStatus.Running)
            {
                //render old geometry
            }
            else
            {
                t = Task.Factory.StartNew(o.CalcNewGeometry())
                        .ContinueWith(p => o.UpdateGeometry); //swap the new geometry in
            }
        }
