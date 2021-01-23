        private void btnCompare_Click(object sender, EventArgs e)
        {
            //Creating dummy data for testing
            List<C1> L1 = new List<C1>() { new C1() { ID = 1 }, new C1() { ID = 4 } };
            List<C2> L2 = new List<C2>() { new C2() { ID = 1 }, new C2() { ID = 2 } };
            List<C3> L3 = new List<C3>() { new C3() { ID = 1 }, new C3() { ID = 2 }, new C3() { ID = 3 } };
            //Creating new list which will contain all the objects without duplicates based on ID column
            List<C4> L4 = new List<C4>();
            //Firstly add all the objects from L1
            L4.AddRange(from l1 in L1 select new C4() { ID = l1.ID });
            //Add only those objects from L2 which are not part of L1
            L4.AddRange(from l22 in L2
                        where !(from l4 in L4 join l2 in L2 on l4.ID equals l2.ID select new { ID = l4.ID }).Any(p => p.ID == l22.ID) 
                        select new C4() { ID = l22.ID });
            //Add only those objects from L3 which are not part of L1 and L2
            L4.AddRange(from l33 in L3
                        where !(from l4 in L4 join l3 in L3 on l4.ID equals l3.ID select new { ID = l4.ID }).Any(p => p.ID == l33.ID)
                        select new C4() { ID = l33.ID });
            //L4 will now contain all IDs without duplicates
        }
        class C1
        {
            public int ID { get; set; }
            //will contain other properties
        }
        class C2
        {
            public int ID { get; set; }
            //will contain other properties
        }
        class C3
        {
            public int ID { get; set; }
            //will contain other properties
        }
        class C4
        {
            public int ID { get; set; }
            //will contain other properties or maybe a combination of all the properties of C1, C2 and C3
        }
