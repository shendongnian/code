    Partial Public Class CustomerController
    	Implements ICustomerController
    
    	Public Function GetCustomerSelectionViewData(ByVal stateFilter As String) As CustomerSelectionViewData Implements ICustomerController.GetCustomerSelectionViewData
    		Return Nothing
    	End Function
    
    	Public Sub UpdateCustomer(ByVal data As CustomerEditViewData) Implements ICustomerController.UpdateCustomer
    	End Sub
    End Class
    
    Partial Public Class CustomerController
    	Inherits BaseController
    	Implements ICustomerController
    
    	Public Sub EditCustomer(ByVal customerId As Integer, ByVal daddy As BaseViewModel) Implements ICustomerController.EditCustomer
    	End Sub
    
    	Public Sub CustomerSelectedForEdit(ByVal data As CustomerListItemViewData, ByVal daddy As BaseViewModel) Implements ICustomerController.CustomerSelectedForEdit
    	End Sub
    End Class
