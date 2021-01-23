    public class ApproverChain
    {
        public static TestEntity Entity { get; set; }
        public static ApproverCategorizer Approver { get; set; }
        public ApproverChain()
        {
            Approver = new StartApprover();
            List<string> approverList = Entity.ApproverList.Split(',').ToList();
            ApproverCategorizer currentApprover = Approver;
            foreach (string approver in approverList)
            {
                switch (approver)
                {
                    case "OfficerA":
                        currentApprover = currentApprover.RegisterNextApprover(new OfficerAApprover());
                        break;
                    case "OfficerB":
                        currentApprover = currentApprover.RegisterNextApprover(new OfficerBApprover());
                        break;
                }
            }
        }
        public string StartProcess()
        {
            Approver.ApproveAmount(Entity);
            return Entity.Status;
        }
    }
    public abstract class ApproverCategorizer
    {
        protected ApproverCategorizer NextApprover { get; private set; }
        public ApproverCategorizer RegisterNextApprover(ApproverCategorizer nextApprover)
        {
            NextApprover = nextApprover;
            return nextApprover;
        }
        public abstract void ApproveAmount(TestEntity entity);
        protected bool IsLast()
        {
            return NextApprover == null;
        }
    }
    public class OfficerAApprover : ApproverCategorizer
    {
        public override void ApproveAmount(TestEntity entity)
        {
            if (entity.Amount <= 300)
            {
                entity.Status = "Approved";
                return;
            }
            if (!IsLast() && string.IsNullOrWhiteSpace(entity.Status))
            {
                NextApprover.ApproveAmount(entity);
                return;
            }
            else
            {
                entity.Status = "Rejected";
            }
        }
    }
