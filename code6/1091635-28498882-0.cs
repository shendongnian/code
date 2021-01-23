     selectedPeople = new ObservableCollection<B>(peopleColl.Select(i => new B(i));
    public class B : A
    {
        public B()
        {
        }
        public B(A a)
        {
           this.firstName = a.firstName;
           this.surname = a.surname;
        }
    }
     
