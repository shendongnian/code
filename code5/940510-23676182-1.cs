    public interface ICar {
        Color Color { get; }
        int Passengers { get; }
        ...
        double GasUsage { get; }
    }
    
    class Car : ICar {
        public Car(Color color, int passengers, int maxSpeed, ..., double gasUsage) {
            this.m_Color = color;
            this.m_Passengers = passengers;
            ...
            this.m_GasUsage
        }
        private Color m_Color;
        private int m_Passengers;
    }
