    <Entry DisplayName="non-private Fields">
      <Entry.Match>
        <And>
          <Kind Is="Field" />
          <Not>
            <Access Is="Private" />
          </Not>
        </And>
      </Entry.Match>
      <Entry.SortBy>
        <Access Order="Public Internal ProtectedInternal Protected Private" />
        <Name Is="Enter Pattern Here" />
      </Entry.SortBy>
    </Entry>
