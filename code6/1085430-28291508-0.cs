    <IntuitResponse xmlns="http://schema.intuit.com/finance/v3" time="2015-02-02T20:36:29.188-08:00">
      <QueryResponse startPosition="1" maxResults="1" totalCount="1">
        <Invoice domain="QBO" sparse="false">
          <Id>1</Id>
          <SyncToken>1</SyncToken>
          <MetaData>
            <CreateTime>2015-02-02T20:34:40-08:00</CreateTime>
            <LastUpdatedTime>2015-02-02T20:36:21-08:00</LastUpdatedTime>
          </MetaData>
          <DocNumber>1001</DocNumber>
          <TxnDate>2015-02-02</TxnDate>
          <CurrencyRef name="United States Dollar">USD</CurrencyRef>
          <Line>
            <Id>1</Id>
            <LineNum>1</LineNum>
            <Description>random dex</Description>
            <Amount>20.00</Amount>
            <DetailType>SalesItemLineDetail</DetailType>
            <SalesItemLineDetail>
              <ItemRef name="Services">12</ItemRef>
              <UnitPrice>20</UnitPrice>
              <Qty>1</Qty>
              <TaxCodeRef>TAX</TaxCodeRef>
            </SalesItemLineDetail>
          </Line>
          <Line>
            <Amount>20.00</Amount>
            <DetailType>SubTotalLineDetail</DetailType>
            <SubTotalLineDetail />
          </Line>
          <TxnTaxDetail>
            <TxnTaxCodeRef>2</TxnTaxCodeRef>
            <TotalTax>2.25</TotalTax>
            <TaxLine>
              <Amount>2.25</Amount>
              <DetailType>TaxLineDetail</DetailType>
              <TaxLineDetail>
                <TaxRateRef>1</TaxRateRef>
                <PercentBased>true</PercentBased>
                <TaxPercent>11.25</TaxPercent>
                <NetAmountTaxable>20.00</NetAmountTaxable>
              </TaxLineDetail>
            </TaxLine>
          </TxnTaxDetail>
          <CustomerRef name="John Doe">1</CustomerRef>
          <SalesTermRef>3</SalesTermRef>
          <DueDate>2015-03-04</DueDate>
          <TotalAmt>22.25</TotalAmt>
          <ApplyTaxAfterDiscount>false</ApplyTaxAfterDiscount>
          <PrintStatus>NotSet</PrintStatus>
          <EmailStatus>NotSet</EmailStatus>
          <Balance>22.25</Balance>
          <Deposit>0</Deposit>
          <AllowIPNPayment>false</AllowIPNPayment>
          <AllowOnlinePayment>false</AllowOnlinePayment>
          <AllowOnlineCreditCardPayment>false</AllowOnlineCreditCardPayment>
          <AllowOnlineACHPayment>false</AllowOnlineACHPayment>
        </Invoice>
      </QueryResponse>
    </IntuitResponse>
