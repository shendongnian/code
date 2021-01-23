    public class Producer
    {
        public event Action<Data> DataProduced;
        public void Produce()
        {
            while (true)
            {
                Thread.Sleep(1000);//placeholder for real work
                DataProduced(new Data());//populate with real data
            }
        }
    }
---
    Producer producer = new Producer();
    producer.DataProduced += data => 
        ThreadPool.QueueUserWorkItem(_ => Consume1(data));
    producer.DataProduced += data => 
        ThreadPool.QueueUserWorkItem(_ => Consume2(data));
    producer.DataProduced += data => 
        ThreadPool.QueueUserWorkItem(_ => Consume3(data));
    producer.Produce();
