    public class EventProcessor : MonoBehaviour {
    
        public void QueueEvent(Action action) {
            lock(m_queueLock) {
                m_queuedEvents.Add(action);
            }
        }
    
        void Start() {
            m_queuedEvents = new List<Action>();
            m_executingEvents = new List<Action>();
        }
    
        void Update() {
            MoveQueuedEventsToExecuting();
    
            while (m_executingEvents.Count > 0) {
                Action e = m_executingEvents[0];
                m_executingEvents.RemoveAt(0);
                e();
            }
        }
    
        private void MoveQueuedEventsToExecuting() {
            lock(m_queueLock) {
                while (m_queuedEvents.Count > 0) {
                    Action e = m_queuedEvents[0];
                    m_executingEvents.Add(e);
                    m_queuedEvents.RemoveAt(0);
                }
            }
        }
    
        private System.Object m_queueLock = new System.Object();
        private List<Action> m_queuedEvents;
        private List<Action> m_executingEvents;
    }
    
