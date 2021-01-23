    class Model1 implements IModel
    {
        IModel m_model;
    
        Model1(CarModel model){
            m_model = model;
        }
    
        public int getPrice(){
            return m_model.getPrice() + getModelSpecificPrice();
        }
    
        protected int getModelSpecificPrice(){
            return 10;
        }
    }
