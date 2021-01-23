    using System.Linq;
    using System.Collections;
    var myFinalList = db.Tables[0].Select()
                .Where(myTable1 =>
                    myIntList.TrueForAll(myInt =>
                        db.Tables[1].Select().Any(myTable2 =>
                            myTable2["field1"] == myTable1["field1"] &&
                            (int)myTable2["field2"] == myInt)
                        &&
                        db.Tables[2].Select().Any(myTable3 =>
                            myTable3["field1"] == myTable1["field1"] &&
                            (int)myTable3["field2"] == myInt))).ToList();
