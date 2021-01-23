	var messageCodesQuery =
		from newMessageCode in newDiffMsgCodeCollection
		from oldMessageCode in oldDiffMsgCodeCollection
		where newMessageCode.MessageCode == oldMessageCode.MessageCode
		select new MessageCodes()
		{
			MessageCode = newMessageCode.MessageCode,
			LangCollection = (
				from newLangNode in newMessageCode.LangCollection
				from oldLangNode in oldMessageCode.LangCollection
				let newCode = newLangNode.Key.Trim().ToLower()
				let oldCode = oldLangNode.Key.Trim().ToLower()
				where newCode == oldCode
				where newLangNode.Value != oldLangNode.Value
				select new { newCode, oldCode }
			).ToDictionary(x => x.newCode, x => x.oldCode)
		};
