    public class MoveCustomerCommand
    {
        public Guid CustomerId;
        public Address NewAddress;
    }
    public class MoveCustomerCommmandHandler : ICommandHandler<MoveCustomerCommand>
    {
        public void Handle(MoveCustomerCommand command)
        {
            // behavior here.
        }
    }
