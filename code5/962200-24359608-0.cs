        // In SUT
        var issue = issueFactory.CreateIssue();
        ...
        // In test
        var stubIssue = new Issue{ ... };
        var issueFactory = new Mock<IIssueFactory>();
        var visitor = new Mock<IIssueVisitor>();
        ...        
        issueFactory.Setup(factory => factory.CreateIssue())
            .Returns(stubIssue);
        visitor.Setup(x => x.Visit(stubIssue));
