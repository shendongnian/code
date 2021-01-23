    IEnumerable<Payment> UnitePayments(List<Payment> list1, List<Payment> list2)
    {
        ... Check that list1 and list2 are the same length ...
        for(int i=0; i<list1.Length; i++)
        {
             if(list1.Period!=list2.Period) ... handle this case...
             yield return new Payment { Period = list1.Period, 
                                        Balance = list1.Balance + list2.Balance };
        }
    }
