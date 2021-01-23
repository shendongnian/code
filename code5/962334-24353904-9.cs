    public class Crud : ICrud
    {
        public bool CreateEntity()
        {
            // exciting business logic
        }
    
        // etc.
    }
    
    public class CrudTestDecorator : ICrud
    {
        private readonly ICrud m_Crud;
    
        public CrudTestDecorator(ICrud crud)
        {
            m_Crud = crud;
        }
    
        public bool CreateEntity()
        {
            if (!m_Crud.CreateEntity())
            {
                throw new Exception("Could not create entity");
            }
        }
    
        // etc.
    }
