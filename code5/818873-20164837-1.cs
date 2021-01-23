    class AbstractModel implements IModel{
            IModel m_model;
    
            AbstractModel(CarModel model){
                m_model = model;
            }
    
            public int getPrice(){
                return m_model.getPrice() + getModelSpecificPrice();
            }
    
            abstract protected int getModelSpecificPrice();
    }
    
    
    class Model1 extends AbstractModel
    {
        
        Model1(CarModel model){
            super(model);
        }
        protected int getModelSpecificPrice(){
            return 10;
        }
    }
