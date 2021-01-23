    public event RequestContractTypeEventHandler RequestContract;
     public void OnDropOptionSelected(string currentContractDescription, string currentContractNumber)
            {
                if (RequestContract != null)
                {
                try{
                    RequestContract(this, new ContractForAccountEventArgs { ContractDescription = currentContractDescription, Contract = currentContractNumber });
                }
                catch(Exception ex){
                    this.lblMsg.Text="something bad happened!";  
                    this.divError.Style.Add("display", "");  
                }
                }
            }     
