    public class ViewModel
    {
        public ViewModel()
        {
            this.Models = new List<Model>
                {
                    new Model
                        {
                            Description = "ModelA", 
                            Models = new List<Model>
                                {
                                    new Model { Description = "ModelA1" },
                                    new Model { Description = "ModelA2" }
                                }
                        },
                    new Model
                        {
                            Description = "ModelB", 
                            Models = new List<Model>
                                {
                                    new Model { Description = "ModelB1" },
                                    new Model
                                        {
                                            Description = "ModelB2", 
                                            Models = new List<Model>
                                                {
                                                    new Model { Description = "ModelB2i" },
                                                    new Model { Description = "ModelB2ii" }
                                                }
                                        }
                                }
                        }
                };
        }
        public List<Model> Models { get; set; }
    }
    public class Model
    {
        public string Description { get; set; }
        public List<Model> Models { get; set; }
    }
