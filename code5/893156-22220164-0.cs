    ArrayList list1 = new ArrayList();
	ArrayList list2 = new ArrayList();
	list1.Add(1);
	list2.Add(1);
	if ((list1.ToArray() as IStructuralEquatable).Equals(list2.ToArray(), EqualityComparer<int>.Default))
	{
		MessageBox.Show("Equal");
	}
